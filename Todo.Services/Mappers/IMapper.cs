namespace Todo.Services.Mappers
{
    public interface IMapper<in TSource, out TTarget> where TSource:class where TTarget:class
    {
        TTarget Map(TSource source);
    }
}