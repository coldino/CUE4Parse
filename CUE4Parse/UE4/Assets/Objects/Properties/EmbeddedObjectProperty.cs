using CUE4Parse.UE4.Assets.Exports;
using CUE4Parse.UE4.Assets.Readers;
using CUE4Parse.UE4.Exceptions;
using CUE4Parse.UE4.Readers;
using Newtonsoft.Json;

namespace CUE4Parse.UE4.Assets.Objects.Properties
{
    [JsonConverter(typeof(EmbeddedObjectPropertyConverter))]
    public class EmbeddedObjectProperty : FPropertyTagType<UObject>
    {
        public string? ObjectName;
        public string? ObjectClass;

        public EmbeddedObjectProperty(FArchive Ar, ReadType type)
        {
            var kind = Ar.ReadByte();
            if (kind == 0) {
                // null object
            } else if (kind == 1) {
                Ar.Position += 4; // unknown word
                ObjectName = Ar.ReadFString();
                ObjectClass = Ar.ReadFString();
            } else if (kind == 3) {
                ObjectName = Ar.ReadFString();
                ObjectClass = Ar.ReadFString();
                Value = new UObject();
                Value.Deserialize((FAssetArchive)Ar, 0);
            } else if (kind == 7) {
                ObjectName = Ar.ReadFString();
                ObjectClass = Ar.ReadFString();
            } else if (kind == 9) {
                ObjectClass = Ar.ReadFString();
            } else {
                throw new ParserException(Ar, $"Unknown embedded object kind {kind}");
            }
        }
    }
}
