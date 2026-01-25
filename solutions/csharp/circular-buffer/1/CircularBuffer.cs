public class CircularBuffer<T>
    {
        private int strBuff = 0;
        private int endBuff = 0;
        private int sizeBuff = 0;
        private T[] buffer;
    
        public CircularBuffer(int capacity) => buffer = new T[capacity];

        public T Read()
        {
            if (sizeBuff == 0) throw new InvalidOperationException("Buffer is empty!");
            var value = buffer[strBuff];
            buffer[strBuff] = default(T);
            strBuff = (strBuff + 1) % buffer.Length;
            sizeBuff--;
            return value;
        }

        public void Write(T value) 
        {
            if (sizeBuff == buffer.Length) throw new InvalidOperationException("Buffer is full!");
            buffer[endBuff] = value;
            endBuff = (endBuff + 1) % buffer.Length;
            sizeBuff++;
        }

        public void Overwrite(T value)
        {
            if (sizeBuff == buffer.Length)
            {
                buffer[endBuff] = value;
                endBuff = (endBuff + 1) % buffer.Length;
                strBuff = (strBuff + 1) % buffer.Length;
            }
            else
            {
                buffer[endBuff] = value;
                endBuff = (endBuff + 1) % buffer.Length;
                sizeBuff++;
            }
        }

        public void Clear() 
        {
            if (sizeBuff > 0)
            {
                for (int i = 0; i < sizeBuff; i++)
                {
                    buffer[(strBuff + i) % buffer.Length] = default(T);
                }
            }
            strBuff = 0;
            endBuff = 0;
            sizeBuff = 0;
        }
    }
