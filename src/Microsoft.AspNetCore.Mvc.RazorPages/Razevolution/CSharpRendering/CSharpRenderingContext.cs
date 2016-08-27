// Copyright(c) .NET Foundation.All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages.Razevolution.IR;
using Microsoft.AspNetCore.Razor;
using Microsoft.AspNetCore.Razor.CodeGenerators;

namespace Microsoft.AspNetCore.Mvc.RazorPages.Razevolution.CSharpRendering
{
    public class CSharpRenderingContext
    {
        public Action<IList<ICSharpSource>> Render { get; set; }

        public CSharpCodeWriter Writer { get; set; }

        public GeneratedClassContext CodeLiterals { get; set; }

        public RazorCodeDocument.ItemCollection Items { get; } = new DefaultItemCollection(); // TODO: Should we extract ItemCollection?

        public ErrorSink ErrorSink { get; set; }

        private class DefaultItemCollection : RazorCodeDocument.ItemCollection
        {
            private readonly Dictionary<object, object> _items;

            public DefaultItemCollection()
            {
                _items = new Dictionary<object, object>();
            }

            public override object this[object key]
            {
                get
                {
                    object value;
                    _items.TryGetValue(key, out value);
                    return value;
                }
                set
                {
                    _items[key] = value;
                }
            }
        }
    }
}
