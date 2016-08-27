// Copyright(c) .NET Foundation.All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.AspNetCore.Mvc.RazorPages.Razevolution.IR
{
    public class RazorDirective : ICSharpSource
    {
        public string Name { get; set; }

        // TODO: This is not what this directive should eventually look like. It's faking "generic".
        public Dictionary<string, string> Data { get; set; }
    }
}
