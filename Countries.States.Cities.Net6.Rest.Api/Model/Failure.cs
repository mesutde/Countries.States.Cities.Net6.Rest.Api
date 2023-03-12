namespace Countries.States.Cities.Net6.Rest.Api.Model
{
    public class Failure<T> : Response<T>
    {
        public Failure(string comment, string message = "Hata") 
        {
            Result = false;
            ResultCode = -1;
            Message = message;
            Comment = comment;
        }
    }
}
