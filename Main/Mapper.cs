
using Core.Mapper.Main;

namespace Core.Main.Mapper;

public class Mapper : ObjectCopyBase, IMapper
{
    private readonly Dictionary<string, PropertyMap[]> _maps = [];

    /// <summary>
    /// Copy an object properties value to another object who shares properties type/Name.
    /// </summary>
    /// <param name="source">Source object</param>
    /// <param name="target">Target Object</param>
    public override void Copy(object source, object target)
    {
        var sourceType = source.GetType();
        var targetType = target.GetType();

        var key = GetMapKey(sourceType, targetType);
        if (!_maps.ContainsKey(key))
        {
            MapTypes(sourceType, targetType);
        }

        var propMap = _maps[key];

        for (var i = 0; i < propMap.Length; i++)
        {
            var prop = propMap[i];
            var sourceValue = prop.Source.GetValue(source, null);
            prop.Target.SetValue(target, sourceValue, null);
        }
    }


    /// <summary>
    /// Copy the object properties to a new object class of type T. T should share properties with the same type/name. 
    /// </summary>
    /// <typeparam name="T">Type of the class</typeparam>
    /// <param name="source">Source</param>
    /// <returns>Object of type T with copied values.</returns>
    public T CopyAndReturn<T>(object source) where T : new()
    {
        var target = new T();
        Copy(source, target);
        return target;
    }


    /// <summary>
    /// Copy a list of source objects into a new enumerable of T
    /// </summary>
    /// <typeparam name="T">Type of objects of the list</typeparam>
    /// <param name="source">Source enumerable.</param>
    /// <returns>Enumerable of type T with copied values.</returns>
    public IEnumerable<T> CopyForAll<T>(IEnumerable<object> source) where T : new()
    {
        var response = new List<T>();
        foreach (var obj in source)
        {
            var objTobeAdded = new T();
            Copy(obj, objTobeAdded);
            response.Add(objTobeAdded);
        }
        return response;
    }

    public override void MapTypes(Type source, Type target)
    {
        var key = GetMapKey(source, target);
        if (_maps.ContainsKey(key))
            return;

        var props = GetMatchingProperties(source, target);
        _maps.Add(key, props.ToArray());
    }

}
