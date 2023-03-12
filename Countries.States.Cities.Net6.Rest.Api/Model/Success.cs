namespace Countries.States.Cities.Net6.Rest.Api.Model
{
    public class Success<T> : Response<T>
    {
        public Success(IEnumerable<T> data, string message, string comment) 
        {
            Result = true;
            ResultCode = 200;
            Message = message;
            Comment = comment;
            Data = data;
            UpdateTime = DateTime.Now.ToString();
        }
    }
}
