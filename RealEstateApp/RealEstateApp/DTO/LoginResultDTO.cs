﻿namespace RealEstateApp.DTO
{
    public class LoginResultDTO
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }

        public static LoginResultDTO Success(string token)
        {
            return new LoginResultDTO { IsSuccess = true, Token = token };
        }

        public static LoginResultDTO Failure(string errorMessage)
        {
            return new LoginResultDTO { IsSuccess = false, ErrorMessage = errorMessage };
        }
    }
}
