﻿namespace LibrarySystem.Api.Helper
{
    public class ResponseApi<T>
    {
        public ResponseApi(int statusCode, T result, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMessageFromStatusCode(StatusCode);
            Data = result;
        }
        private string GetMessageFromStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Done",
                201 => "Created successfully",
                204 => "No Content",
                400 => "Bad Request",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Not Found",
                409 => "Conflict",
                422 => "Unprocessable Entity",
                500 => "Internal Server Error",
                502 => "Bad Gateway",
                503 => "Service Unavailable",
                _ => "Unknown Status Code"
            };
        }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T Data { get; set; }

    }
}
