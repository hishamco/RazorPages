// Copyright(c) .NET Foundation.All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Globalization;
using Microsoft.AspNetCore.Razor.CodeGenerators;

namespace Microsoft.AspNetCore.Mvc.RazorPages.Razevolution.CSharpRendering
{
    public static class CSharpCodeWriterExtensions
    {
        public static CSharpCodeWriter WriteLineNumberDirective(this CSharpCodeWriter writer, MappingLocation location, string file)
        {
            if (location.FilePath != null)
            {
                file = location.FilePath;
            }

            if (writer.Builder.Length >= writer.NewLine.Length && !writer.IsAfterNewLine)
            {
                writer.WriteLine();
            }

            var lineNumberAsString = (location.LineIndex + 1).ToString(CultureInfo.InvariantCulture);
            return writer.Write("#line ").Write(lineNumberAsString).Write(" \"").Write(file).WriteLine("\"");
        }

        public static IDisposable BuildLinePragma(this CSharpCodeWriter writer, MappingLocation documentLocation)
        {
            return new LinePragmaWriter(writer, documentLocation);
        }
    }
}
