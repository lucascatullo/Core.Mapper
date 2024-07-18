
namespace Core.Mapper.Main;

public abstract class ObjectCopyBase
{
    public abstract void MapTypes(Type source, Type target);
    public abstract void Copy(object source, object target);

    /// <summary>
    /// Search for a enumerable of propertyMap objects. Properties matching Type/Name beetween source and target types. 
    /// </summary>
    /// <param name="sourceType">Type of the source</param>
    /// <param name="targetType">Type of the target</param>
    /// <returns>Enumerable of propertyMap</returns>
    protected virtual IEnumerable<PropertyMap> GetMatchingProperties(Type sourceType, Type targetType)
    {
        var sourceProperties = sourceType.GetProperties().ToList();
        var targetProperties = targetType.GetProperties().ToList();

        var properties = from s in sourceProperties
                         from t in targetProperties
                         where s.Name == t.Name &&
                               s.CanRead &&
                               t.CanWrite &&
                               s.PropertyType == t.PropertyType
                         select new PropertyMap
                         {
                             Source = s,
                             Target = t
                         };
        return properties;
    }

    protected virtual string GetMapKey(Type sourceType, Type targetType)
    {
        var keyName = "Copy_";
        keyName += sourceType.FullName?.Replace(".", "_").Replace("+", "_");
        keyName += "_";
        keyName += targetType.FullName?.Replace(".", "_").Replace("+", "_");

        return keyName;
    }
}
