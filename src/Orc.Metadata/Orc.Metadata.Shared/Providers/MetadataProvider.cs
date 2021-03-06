﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetadataProvider.cs" company="WildGums">
//   Copyright (c) 2008 - 2015 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Metadata
{
    using System.Threading.Tasks;
    using Catel.Threading;

    public class MetadataProvider : IMetadataProvider
    {
        [ObsoleteEx(RemoveInVersion = "2.0.0", TreatAsErrorFromVersion = "1.1.0", ReplacementTypeOrMember = "GetMetadataAsync")]
        public virtual IObjectWithMetadata GetMetadata(object obj)
        {
            // By default we use reflection, user can always register their own IMetadataProvider
            return new ReflectionObjectWithMetadata(obj);
        }

        public virtual Task<IObjectWithMetadata> GetMetadataAsync(object obj)
        {
            // By default we use reflection, user can always register their own IMetadataProvider
            return TaskHelper<IObjectWithMetadata>.FromResult(new ReflectionObjectWithMetadata(obj));
        }
    }
}