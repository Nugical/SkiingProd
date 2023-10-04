namespace API.Errors
{
    public class ApiResponse
    {
        private string Message { get; set; }
        private int StatusCode { get; set; }    

        public ApiResponse(int status, string message)
        {
            StatusCode = status;
            Message = message ?? GetDefaultMessageForStatusCode(status);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career change."
            };  
        }
    }
}
