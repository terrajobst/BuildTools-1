// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Build.Framework;
using NuGet.Tasks.Policies;

namespace NuGet.Tasks
{
    internal class MSBuildPolicyFactory
    {
        public virtual INuGetPolicy Create(string type, IEnumerable<ITaskItem> items)
        {
            switch (type.ToLowerInvariant())
            {
                case "additionalrestoresource":
                    return new AdditionalProjectRestoreSourcePolicy(items.ToArray());
                case "lineup":
                    return new PackageLineupPolicy(items.ToArray());
                case "disallowpackagereferenceversion":
                    return new PackageVersionRestrictionPolicy(items.ToArray());
                default:
                    return null;
            }
        }
    }
}
