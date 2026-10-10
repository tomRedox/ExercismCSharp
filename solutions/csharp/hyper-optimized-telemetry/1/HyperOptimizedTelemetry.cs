public static class TelemetryBuffer
{
    const int LongLength = 8;
    const int UintLength = 4;
    const int IntLength = 4;
    const int UshortLength = 2;
    const int ShortLength = 2;
    const int SignedTypeAdjustment = 256;
    
    public static byte[] ToBuffer(long reading)
    {
        byte[] readingAsBytes; 

        byte lengthInBytes = 0;
        bool signedType = false;

        // 4_294_967_296	9_223_372_036_854_775_807	long
        if (reading > uint.MaxValue && reading <= long.MaxValue) 
        {
            lengthInBytes = LongLength;
            signedType = true;
            readingAsBytes = BitConverter.GetBytes((long)reading);
        }    
        // 2_147_483_648	4_294_967_295	uint
        else if (reading > int.MaxValue && reading <= uint.MaxValue) 
        {
            lengthInBytes = UintLength;
            signedType = false;
            readingAsBytes = BitConverter.GetBytes((uint)reading);
        }
        // 65_536	2_147_483_647	int
         else if (reading > ushort.MaxValue && reading <= int.MaxValue)
        {
            lengthInBytes = IntLength;
            signedType = true;
            readingAsBytes = BitConverter.GetBytes((int)reading);
        }
        // 0	65_535	ushort
        else if (reading >= 0 && reading <= ushort.MaxValue)
        {
            lengthInBytes = UshortLength;    
            signedType = false;
            readingAsBytes = BitConverter.GetBytes((ushort)reading);
        }
        // -32_768	-1	short
        else if (reading >= short.MinValue && reading <= -1)
        {
            lengthInBytes = ShortLength;    
            signedType = true;
            readingAsBytes = BitConverter.GetBytes((short)reading);
        }
        // -2_147_483_648	-32_769	int        
        else if (reading >= int.MinValue && reading < short.MinValue)
        {
            lengthInBytes = IntLength;
            signedType = true;
            readingAsBytes = BitConverter.GetBytes((int)reading);
        }
        // -9_223_372_036_854_775_808	-2_147_483_649	long        
        else if (reading >= long.MinValue && reading < int.MinValue)
        {
            lengthInBytes = LongLength;
            signedType = true;
            readingAsBytes = BitConverter.GetBytes((long)reading);
        }
        else 
        {
            readingAsBytes = [];
        }

        foreach(byte readingByte in readingAsBytes)
        {
            Console.WriteLine(readingByte);       
        }

        byte prefix = (byte)(signedType ? (SignedTypeAdjustment - lengthInBytes) : lengthInBytes);
        Console.WriteLine($"Prefix: {prefix}");       

        byte[] resultBytes = new byte[9];
        resultBytes[0] = prefix;
        readingAsBytes.CopyTo(resultBytes, 1);

        Console.WriteLine("results bytes:"); 
        foreach(byte resultByte in resultBytes)
        {
            Console.WriteLine(resultByte);       
        }

        return resultBytes;
    }
    
    public static long FromBuffer(byte[] buffer)
    {
        Console.WriteLine("Buffer:");
        foreach(byte bufferByte in buffer)
        {
            Console.WriteLine(bufferByte);       
        }

        int prefixValue = buffer[0];
        Console.WriteLine($"prefixValue: {prefixValue}"); 
        
        long number = 0;
        byte[] bytesToConsider;
        
        if (prefixValue == SignedTypeAdjustment - LongLength) 
        {
            bytesToConsider = new byte[LongLength];
            Array.Copy(buffer, 1, bytesToConsider, 0, LongLength);
            number = BitConverter.ToInt64(bytesToConsider);
        }    
        else if (prefixValue == SignedTypeAdjustment - IntLength) 
        {
            bytesToConsider = new byte[IntLength];
            Array.Copy(buffer, 1, bytesToConsider, 0, IntLength);
            number = BitConverter.ToInt32(bytesToConsider);
        }    
        else if (prefixValue == SignedTypeAdjustment - ShortLength) 
        {
            bytesToConsider = new byte[ShortLength];
            Array.Copy(buffer, 1, bytesToConsider, 0, ShortLength);
            number = BitConverter.ToInt16(bytesToConsider);
         }    
        else if (prefixValue == UshortLength) 
        {
            bytesToConsider = new byte[UshortLength];
            Array.Copy(buffer, 1, bytesToConsider, 0, UshortLength);
            number = BitConverter.ToUInt16(bytesToConsider);
        }    
        else if (prefixValue == UintLength) 
        {
            bytesToConsider = new byte[UintLength];
            Array.Copy(buffer, 1, bytesToConsider, 0, UintLength);
            number = BitConverter.ToUInt32(bytesToConsider);
        }    

        return number;
    }
}
