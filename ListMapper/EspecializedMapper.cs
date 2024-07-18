
namespace Core.Mapper.ListMapper;

public abstract class EspecializeMapper<T> : Core.Main.Mapper.Mapper, IEspecializeMapper<T> where T : class
{
    /// <summary>
    /// Use to map complex objects. (Anidations of view models) 
    /// </summary>
    /// <param name="source">Source object</param>
    /// <returns>Mapped Dictionary</returns>
    public abstract IDictionary<string, object> BuildVM(T source);
    /// <summary>
    /// Use to map an array of T objects. 
    /// </summary>
    /// <param name="sources">Array of T</param>
    /// <returns>Dictionary of mapped Arrays.</returns>
    public IEnumerable<IDictionary<string, object>> BuildVM(T[] sources) => sources.Select(BuildVM);

}
