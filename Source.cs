namespace VarTypes
    {
        public class VarUInt
        {
            public byte[] Value { get; private set; }

            public VarUInt(uint value)
            {
                List<byte> vibl = new List<byte>();
                while(value != 0)
                {
                    vibl.Add((byte)(value & 127 | 128));
                    value = (value >> 7);
                }
                vibl.Add((byte)value);

                byte[] viba = vibl.ToArray();
                Value = viba;
            }

            public uint ToUInt()
            {
                uint value = 0;
                int size = 0;
                int b;
                for(int i=0; ((b = Value[i]) & 0x80) == 0x80; i++)
                {
                    value |= (uint)((b & 0x7F) << (size++ * 7));
                }
                return (uint)(value | ((b & 0x7F) << (size * 7)));
            }

            public static VarUInt operator +(VarUInt left, VarUInt right)
            {
                return new VarUInt(left.ToUInt() + right.ToUInt());
            }
            public static VarUInt operator -(VarUInt left, VarUInt right)
            {
                return new VarUInt(left.ToUInt() - right.ToUInt());
            }
            public static VarUInt operator *(VarUInt left, VarUInt right)
            {
                return new VarUInt(left.ToUInt() * right.ToUInt());
            }
            public static VarUInt operator /(VarUInt left, VarUInt right)
            {
                return new VarUInt(left.ToUInt() / right.ToUInt());
            }
            public static bool operator ==(VarUInt left, VarUInt right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for(int i=0; i<left.Value.Length; i++)
                {
                    if (left.Value[i] != right.Value[i]) { return false; }
                }
                return true;
            }
            public static bool operator !=(VarUInt left, VarUInt right)
            {
                if (left.Value.Length != right.Value.Length) { return true; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] != right.Value[i]) { return true; }
                }
                return false;
            }

            public static explicit operator VarUInt(VarInt v)
            {
                return new VarUInt((uint)v.ToInt());
            }
        }
        public class VarInt
        {
            public byte[] Value { get; private set; }

            public VarInt(int value)
            {
                List<byte> vibl = new List<byte>();
                while (value != 0)
                {
                    vibl.Add((byte)(value & 127 | 128));
                    value = (value >> 7);
                }
                vibl.Add((byte)value);

                byte[] viba = vibl.ToArray();
                Value = viba;
            }

            public int ToInt()
            {
                uint value = 0;
                int size = 0;
                int b;
                for (int i = 0; ((b = Value[i]) & 0x80) == 0x80; i++)
                {
                    value |= (uint)((b & 0x7F) << (size++ * 7));
                }
                return (int)(value | ((b & 0x7F) << (size * 7)));
            }

            public static VarInt operator +(VarInt left, VarInt right)
            {
                return new VarInt(left.ToInt() + right.ToInt());
            }
            public static VarInt operator -(VarInt left, VarInt right)
            {
                return new VarInt(left.ToInt() - right.ToInt());
            }
            public static VarInt operator *(VarInt left, VarInt right)
            {
                return new VarInt(left.ToInt() * right.ToInt());
            }
            public static VarInt operator /(VarInt left, VarInt right)
            {
                return new VarInt(left.ToInt() / right.ToInt());
            }
            public static bool operator ==(VarInt left, VarInt right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] != right.Value[i]) { return false; }
                }
                return true;
            }
            public static bool operator !=(VarInt left, VarInt right)
            {
                if (left.Value.Length != right.Value.Length) { return true; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] != right.Value[i]) { return true; }
                }
                return false;
            }
            public static bool operator >=(VarInt left, VarInt right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] < right.Value[i]) { return false; }
                }
                return true;
            }
            public static bool operator <=(VarInt left, VarInt right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] > right.Value[i]) { return false; }
                }
                return true;
            }
            public static bool operator <(VarInt left, VarInt right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] >= right.Value[i]) { return false; }
                }
                return true;
            }
            public static bool operator >(VarInt left, VarInt right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] <= right.Value[i]) { return false; }
                }
                return true;
            }

            public static explicit operator VarInt(VarUInt v)
            {
                return new VarInt((int)v.ToUInt());
            }
        }
    }
