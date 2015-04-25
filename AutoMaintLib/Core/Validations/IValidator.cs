using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMaintLib.Core.Validations
{
    public interface IValidator<T>
    {
        bool Validate(T item);
        IEnumerable<string> Errors(T item);
    }
}
