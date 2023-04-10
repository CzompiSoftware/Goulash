using System.Collections.Generic;
using Goulash.Protocol.Models;

namespace Goulash.Core;

public interface ISearchResponseBuilder
{
    SearchResponse BuildSearch(IReadOnlyList<PackageRegistration> results);
    AutocompleteResponse BuildAutocomplete(IReadOnlyList<string> data);
    DependentsResponse BuildDependents(IReadOnlyList<PackageDependent> results);
}
