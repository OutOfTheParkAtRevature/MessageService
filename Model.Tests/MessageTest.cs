﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;
using Models;

namespace Model.Tests
{
    public class MessageTest
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
        /// Makes sure Message Model works with valid data
        /// </summary>
        /// 
        [Fact]
        public void ValidateMessage()
        {
            var message = new Message()
            {
                MessageID = Guid.NewGuid(),
                SenderID = Guid.NewGuid(),
                RecipientListID = Guid.NewGuid(),
                SentDate = DateTime.Now,
                MessageText = "This is a test message"
            };

            var results = ValidateModel(message);
            Assert.True(results.Count == 0);
        }


    }
}
