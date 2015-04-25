using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Core.Validations
{
    public interface IValidatable<T>
    {
        bool IsValid(IValidator<T> validator, out IEnumerable<string> errors);
    }
}
