using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Result<T>
    {
        public T Value { get; set; }
        public string Error { get; set; }
        public string[] ErrorParams { get; set;}
        public bool IsSuccess 
        { 
            get {
                return Value != null;
            }
        }
        public bool IsFailure 
        {
            get {
                return !IsSuccess;
            }
        }

        public static Result<T> Succeed (T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> Fail(string error, string[] errorParams) {
            return new Result<T>(error, errorParams);
        }

        public static Result<T> Fail(string error) {
            return new Result<T>(error, new string[] {});
        }
        
        private Result(T value)
        {
            Value = value;
            Error = string.Empty;
            ErrorParams = new string[] {};
        }

        private Result(string error, string[] errorParams) {
            Error = error;
            ErrorParams = errorParams;
        }
    }
}
