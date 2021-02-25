using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Model.Tests
{
    public class RecipientListTest
    {
        /// <summary>
        /// Checks the data annotations of Models to make sure they aren't being violated
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private IList<ValidationResult> ValidateModel(object model)
        {
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);
            Validator.TryValidateObject(model, validationContext, result, true);
            // if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);

            return result;
        }

        /// <summary>
        /// Makes sure UserInbox Model works with valid data
        /// </summary>
        /// 
        [Fact]
        public void ValidateMessage()
        {
            var recipientList = new RecipientList()
            {
               RecipientListID = Guid.NewGuid(),
               RecipientID = "1234567"
            };

            var results = ValidateModel(recipientList);
            Assert.True(results.Count == 0);
        }

    }
}
