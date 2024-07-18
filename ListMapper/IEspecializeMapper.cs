using Core.Main.Mapper;

namespace Core.Mapper.ListMapper;

public interface IEspecializeMapper<T> : IMapper where T : class
{
    IDictionary<string, object> BuildVM(T source);
}