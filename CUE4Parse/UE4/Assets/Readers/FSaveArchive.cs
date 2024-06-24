using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CUE4Parse.UE4.Assets.Utils;
using CUE4Parse.UE4.Objects.UObject;
using CUE4Parse.UE4.Readers;

namespace CUE4Parse.UE4.Assets.Readers
{
    public class FSaveArchive : FAssetArchive
    {
        public FSaveArchive(FArchive baseArchive, IPackage? owner, int absoluteOffset = 0, Dictionary<PayloadType, Lazy<FAssetArchive?>>? payloads = null) : base(baseArchive, owner, absoluteOffset, payloads)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override FName ReadFName() => new(ReadFString());
    }
}
