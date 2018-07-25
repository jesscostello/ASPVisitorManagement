using System.Collections.Generic;

namespace ASPVisitorManagement.Services
{
    public interface ITextFileOperations
    {
        IEnumerable<string> LoadCondiditonsForAcceptanceText();
    }
}