using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNRPropMover.Types
{
    internal static class BinFormatter
    {
        public static string ToHexDump(this byte[] buffer)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Offset(h) 00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F  Decoded text");
            sb.AppendLine();

            foreach (var line in buffer.Chunk(16).Select((chunk, index) => new { Index = index, Chunk = chunk }))
            {
                sb.Append($"{line.Index * 16:X8}  ");
                foreach (var b in line.Chunk)
                {
                    sb.Append($"{b:X2} ");
                }
                // Pad the line if it's less than 16 bytes
                if (line.Chunk.Length < 16)
                {
                    sb.Append(new string(' ', (16 - line.Chunk.Length) * 3));
                }
                sb.Append(" ");
                foreach (var b in line.Chunk)
                {
                    sb.Append(char.IsControl((char)b) ? '.' : (char)b);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static string ToBinDump(this int value)
        {
            var sb = new StringBuilder();

            var bits = sizeof(int) * 8;

            sb.Append("Bit(b)");

            for (int i = 0; i < bits; i++)
            {
                sb.Append($" {i.ToString().PadLeft(2, '0')}");
            }

            sb.AppendLine("  Value");
            sb.Append("      ");

            for (int i = 0; i < bits; i++)
            {
                sb.Append($"  {(((value >> i) & 1) != 0 ? "1" : "0")}");
            }

            sb.AppendLine($"  0x{value:x}");

            return sb.ToString();
        }
    }
}
