// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.AspNetCore.Mvc.RazorPages.Razevolution.IR
{
    // TODO: Incorporate into normal RazorDocumentExtensions
    public static class IRRazorCodeDocumentExtensions
    {
        public static string GetChecksumBytes(this RazorCodeDocument document)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            return (string)document.Items[typeof(Checksum)];
        }

        // TODO: This needs to be set somewhere
        public static void SetChecksumBytes(this RazorCodeDocument document, string bytes)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }

            document.Items[typeof(Checksum)] = bytes;
        }

        public static CSharpSourceTree GetSourceTree(this RazorCodeDocument document)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            return (CSharpSourceTree)document.Items[typeof(CSharpSourceTree)];
        }

        public static void SetSourceTree(this RazorCodeDocument document, CSharpSourceTree sourceTree)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            if (sourceTree == null)
            {
                throw new ArgumentNullException(nameof(sourceTree));
            }

            document.Items[typeof(CSharpSourceTree)] = sourceTree;
        }
    }
}
