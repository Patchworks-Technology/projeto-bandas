namespace ProjetoBandas.Response
{
    public class JsonBaseResponse<T> where T : class
    {
        public T Data { get; set; }
    }
}