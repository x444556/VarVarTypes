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
            public static explicit operator VarUInt(VarLong v)
            {
                return new VarUInt((uint)v.ToLong());
            }
            public static explicit operator VarUInt(VarULong v)
            {
                return new VarUInt((uint)v.ToULong());
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
            public static explicit operator VarInt(VarLong v)
            {
                return new VarInt((int)v.ToLong());
            }
            public static explicit operator VarInt(VarULong v)
            {
                return new VarInt((int)v.ToULong());
            }
        }
        public class VarLong
        {
            public byte[] Value { get; private set; }

            public VarLong(long value)
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

            public long ToLong()
            {
                long value = 0;
                int size = 0;
                int b;
                for (int i = 0; ((b = Value[i]) & 0x80) == 0x80; i++)
                {
                    value |= (b & 0x7F) << (size++ * 7);
                }
                return value | ((b & 0x7F) << (size * 7));
            }

            public static VarLong operator +(VarLong left, VarLong right)
            {
                return new VarLong(left.ToLong() + right.ToLong());
            }
            public static VarLong operator -(VarLong left, VarLong right)
            {
                return new VarLong(left.ToLong() - right.ToLong());
            }
            public static VarLong operator *(VarLong left, VarLong right)
            {
                return new VarLong(left.ToLong() * right.ToLong());
            }
            public static VarLong operator /(VarLong left, VarLong right)
            {
                return new VarLong(left.ToLong() / right.ToLong());
            }
            public static bool operator ==(VarLong left, VarLong right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] != right.Value[i]) { return false; }
                }
                return true;
            }
            public static bool operator !=(VarLong left, VarLong right)
            {
                if (left.Value.Length != right.Value.Length) { return true; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] != right.Value[i]) { return true; }
                }
                return false;
            }
            public static bool operator >=(VarLong left, VarLong right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] < right.Value[i]) { return false; }
                }
                return true;
            }
            public static bool operator <=(VarLong left, VarLong right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] > right.Value[i]) { return false; }
                }
                return true;
            }
            public static bool operator <(VarLong left, VarLong right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] >= right.Value[i]) { return false; }
                }
                return true;
            }
            public static bool operator >(VarLong left, VarLong right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] <= right.Value[i]) { return false; }
                }
                return true;
            }

            public static explicit operator VarLong(VarInt v)
            {
                return new VarLong((long)v.ToInt());
            }
            public static explicit operator VarLong(VarUInt v)
            {
                return new VarLong((long)v.ToUInt());
            }
            public static explicit operator VarLong(VarULong v)
            {
                return new VarLong((long)v.ToULong());
            }
        }
        public class VarULong
        {
            public byte[] Value { get; private set; }

            public VarULong(ulong value)
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

            public ulong ToULong()
            {
                ulong value = 0;
                int size = 0;
                int b;
                for (int i = 0; ((b = Value[i]) & 0x80) == 0x80; i++)
                {
                    value |= (ulong)(b & 0x7F) << (size++ * 7);
                }
                return value | (ulong)((b & 0x7F) << (size * 7));
            }

            public static VarULong operator +(VarULong left, VarULong right)
            {
                return new VarULong(left.ToULong() + right.ToULong());
            }
            public static VarULong operator -(VarULong left, VarULong right)
            {
                return new VarULong(left.ToULong() - right.ToULong());
            }
            public static VarULong operator *(VarULong left, VarULong right)
            {
                return new VarULong(left.ToULong() * right.ToULong());
            }
            public static VarULong operator /(VarULong left, VarULong right)
            {
                return new VarULong(left.ToULong() / right.ToULong());
            }
            public static bool operator ==(VarULong left, VarULong right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] != right.Value[i]) { return false; }
                }
                return true;
            }
            public static bool operator !=(VarULong left, VarULong right)
            {
                if (left.Value.Length != right.Value.Length) { return true; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] != right.Value[i]) { return true; }
                }
                return false;
            }
            public static bool operator >=(VarULong left, VarULong right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] < right.Value[i]) { return false; }
                }
                return true;
            }
            public static bool operator <=(VarULong left, VarULong right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] > right.Value[i]) { return false; }
                }
                return true;
            }
            public static bool operator <(VarULong left, VarULong right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] >= right.Value[i]) { return false; }
                }
                return true;
            }
            public static bool operator >(VarULong left, VarULong right)
            {
                if (left.Value.Length != right.Value.Length) { return false; }
                for (int i = 0; i < left.Value.Length; i++)
                {
                    if (left.Value[i] <= right.Value[i]) { return false; }
                }
                return true;
            }

            public static explicit operator VarULong(VarLong v)
            {
                return new VarULong((ulong)v.ToLong());
            }
            public static explicit operator VarULong(VarUInt v)
            {
                return new VarULong((ulong)v.ToUInt());
            }
            public static explicit operator VarULong(VarInt v)
            {
                return new VarULong((ulong)v.ToInt());
            }
        }
    }
