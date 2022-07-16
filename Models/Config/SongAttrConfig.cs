using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Slider5.Models.Config
{
    public class ExtensionAttribute : ValidationAttribute
    {
        private readonly string[] _allowedExtension;

        public ExtensionAttribute(string[] extensions)
        {
            _allowedExtension = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var ext = Path.GetExtension(file.FileName);
                if (!_allowedExtension.Contains(ext.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult(GetErrorMessage());
            }
        }

        public string GetErrorMessage()
        {
            return "This file extension is not valid!";
        }
    }
}
