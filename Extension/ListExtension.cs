
using Core.Mapper.Extension;
using Core.Mapper.ListMapper;

namespace Core.Mapper.Extension;

public static class ListExtension
{
    public static IEnumerable<IDictionary<string, object>>
        BuildVM<T>(this IList<T> source, IEspecializeMapper<T> mapper) where T : class
        => source.Select(mapper.BuildVM);


    public static IEnumerable<IDictionary<string, object>>
        BuildVM<T>(this IEnumerable<T> source, IEspecializeMapper<T> mapper) where T : class
        => source.Select(mapper.BuildVM);
}
