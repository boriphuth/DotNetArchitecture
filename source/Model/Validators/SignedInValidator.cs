using FluentValidation;
using Solution.Core.Validation;
using Solution.CrossCutting.Resources;
using Solution.Model.Models;

namespace Solution.Model.Validators
{
    public sealed class SignedInValidator : Validator<SignedInModel>
    {
        public SignedInValidator() : base(Texts.LoginPasswordInvalid)
        {
            RuleFor(x => x).NotNull();
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
