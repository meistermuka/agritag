using AgriTag.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq;

namespace AgriTag.Common.Helpers
{
    public static class ControllerHelpers
    {
        public static bool ContainsValidProduceTypeJsonPatchPath(JsonPatchDocument<ProduceType> patchDocument)
        {
            List<string> validFields = new()
            {
                "name",
                "description"
            };

            return IsValidSetOfOperations(patchDocument, validFields);
        }
        private static bool IsValidSetOfOperations<T>(JsonPatchDocument<T> patchDoc, List<string> validFields) where T : class
        {
            foreach (var op in patchDoc.Operations)
            {
                if (!string.IsNullOrWhiteSpace(op.path))
                {
                    var pathToValidate = op.path.Trim('/').ToLowerInvariant();
                    if (!validFields.Contains(pathToValidate))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
