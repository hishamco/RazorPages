// Copyright(c) .NET Foundation.All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Mvc.RazorPages.Razevolution.IR;

namespace Microsoft.AspNetCore.Mvc.RazorPages.Razevolution.CSharpRendering
{
    public class InjectDirectiveRenderer : ICSharpRenderer
    {
        private readonly string _injectAttribute;

        public InjectDirectiveRenderer(string injectAttribute)
        {
            _injectAttribute = $"[{injectAttribute}]";
        }

        public RazorEngine Engine { get; set; }

        public int Order { get; } = 1;

        public bool TryRender(ICSharpSource source, CSharpRenderingContext context)
        {
            var directive = source as RazorDirective;
            if (string.Equals(directive?.Name, "inject", StringComparison.Ordinal))
            {
                context.Writer
                    .WriteLine(_injectAttribute)
                    .Write("public global::")
                    .Write(directive.Data["TypeName"])
                    .Write(" ")
                    .Write(directive.Data["MemberName"])
                    .WriteLine(" { get; private set; }");

                return true;
            }

            return false;
        }
    }
}
