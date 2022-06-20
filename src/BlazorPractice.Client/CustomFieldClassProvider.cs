﻿using Microsoft.AspNetCore.Components.Forms;

namespace BlazorPractice.Client
{
    public class CustomFieldClassProvider : FieldCssClassProvider
    {
        public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
        {
            var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

            return isValid ? "validField" : "invalidField";
        }
    }
}
