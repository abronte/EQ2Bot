using System;

namespace EQWaypoint
{

	public class MemoryLoc
	{
		int mAddress;
		System.Diagnostics.Process mProcess;

		public MemoryLoc(System.Diagnostics.Process process, int address)
		{
			this.mProcess = process;
			this.mAddress = address;
		}

		public int Address
		{
			get { return this.mAddress; }
		}

		public float GetFloat()
		{
			byte[] bytes = new byte[4];

			WindowsAPI.Peek(this.mProcess, this.mAddress, bytes);

			return BitConverter.ToSingle(bytes, 0);
		}

		public int GetInt32()
		{
			byte[] bytes = new byte[4];

			WindowsAPI.Peek(this.mProcess, this.mAddress, bytes);

			return BitConverter.ToInt32(bytes, 0);
		}
		
		public int GetInt16()
		{
			byte[] bytes = new byte[2];

			WindowsAPI.Peek(this.mProcess, this.mAddress, bytes);

			return BitConverter.ToInt16(bytes, 0);
		}

		public void SetValue(float val)
		{
			byte[] bytes = BitConverter.GetBytes(val);
			
			WindowsAPI.Poke(this.mProcess, this.mAddress, bytes);
		}
		
		public void SetValueInt8(byte val)
		{
			byte[] bytes = BitConverter.GetBytes(val);
			WindowsAPI.Poke(this.mProcess, this.mAddress, bytes);
		}
		
		public void SetValueInt16(ushort val)
		{
			byte[] bytes = BitConverter.GetBytes(val);
			WindowsAPI.Poke(this.mProcess, this.mAddress, bytes);
		}
		public void SetValueInt32(uint val)
        {
            byte[] bytes = BitConverter.GetBytes(val);
            WindowsAPI.Poke(this.mProcess, this.Address, bytes);
		}

		public void SetBytes(byte[] b){
			WindowsAPI.Poke(this.mProcess, this.Address, b);
		}
	}
}
