﻿using EnvDTE;
using Typewriter.Metadata.Interfaces;
using Typewriter.Metadata.Providers;

namespace Typewriter.Metadata.CodeDom
{
    public class CodeDomMetadataProvider : IMetadataProvider
    {
        private readonly DTE dte;

        public CodeDomMetadataProvider(DTE dte)
        {
            this.dte = dte;
        }

        public IFileMetadata GetFile(string path)
        {
            var projectItem = dte.Solution.FindProjectItem(path);
            if (projectItem != null)
            {
                return new CodeDomFileMetadata(projectItem);
            }

            return null;
        }
    }
}
