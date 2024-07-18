

namespace Core.Main.Mapper;

public interface IMapper
{
    void Copy(object source, object target);
    void MapTypes(Type source, Type target);
    T CopyAndReturn<T>(object source) where T : new();
    IEnumerable<T> CopyForAll<T>(IEnumerable<object> source) where T : new();
}