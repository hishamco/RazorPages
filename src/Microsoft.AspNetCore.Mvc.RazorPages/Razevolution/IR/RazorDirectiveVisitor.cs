// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Microsoft.AspNetCore.Mvc.RazorPages.Razevolution.IR
{
    public class RazorDirectiveVisitor : ChunkVisitor
    {
        private readonly CSharpSourceLoweringContext _context;

        public RazorDirectiveVisitor(CSharpSourceLoweringContext context)
        {
            _context = context;
        }

        protected override void Visit(ModelChunk chunk)
        {
            // TODO: Remove this ModelChunk handling point, make directives more generic.

            var modelDirective = new RazorDirective
            {
                Name = "model",
                Data = new Dictionary<string, string>
                {
                    ["TypeName"] = chunk.ModelType,
                },
            };
            _context.Builder.Add(modelDirective);
        }

        protected override void Visit(InjectChunk chunk)
        {
            // TODO: Remove this InjectChunk handling point, make directives more generic.

            var injectDirective = new RazorDirective
            {
                Name = "inject",
                Data = new Dictionary<string, string>
                {
                    ["TypeName"] = chunk.TypeName,
                    ["MemberName"] = chunk.MemberName
                },
            };
            _context.Builder.Add(injectDirective);
        }
    }
}