using System;

namespace task2
{
    class VectorDecimal
    {
        private decimal[] _decimalArray;
        private uint _size;
        private int _codeError;
        private static uint _num_vec;

        public decimal[] DecimalArray {get { return _decimalArray;} set { _decimalArray = value;}}
        public uint Size {get {return _size;}}
        public int CodeError {get{return _codeError;} set{_codeError = value;}}

        public decimal this[uint i]
        {
            get
            {
                if(i < _size)
                    return _decimalArray[i];
                else
                    return 0;
            }
            set
            {
                if(i < _size)
                    _decimalArray[i] = value;
                else
                    _codeError = -1;
            }
        }
        

        public VectorDecimal()
        {
            _decimalArray = new decimal[1];
            _decimalArray[0] = 0;
            _size = 1;
            _codeError = 0;
            _num_vec++;
        }
        public VectorDecimal(uint size)
        {
            _size = size;
            _decimalArray = new decimal[size];
            for (int i = 0; i < size; i++)
            {
                _decimalArray[i] = 0;
            }
            _codeError = 0;
            _num_vec++;
        }
        public VectorDecimal(uint size, decimal value)
        {
            _size = size;
            _decimalArray = new decimal[size];
            for(int i = 0; i < size; i++)
            {
                _decimalArray[i] = value;
            }
            _codeError = 0;
            _num_vec++;
        }

        ~VectorDecimal() => Console.WriteLine($"Destructor is executing");

        public void SetVector()
        {
            Console.WriteLine("Input decimals: ");
            decimal test = 0;
            for (int i = 0; i < _size; i++)
            {
                Console.Write("Index "+i+": ");
                while(!Decimal.TryParse(Console.ReadLine(), out test))
                {
                    Console.Write("Wrong decimal! Try again: ");
                }
                _decimalArray[i] = Convert.ToDecimal(test);
            }

        }
        public void GetVector()
        {
            Console.Write("Vector = [");
            for(int i = 0; i < _size; i++)
                if(i == _size-1)
                    Console.Write(_decimalArray[i]);
                else
                    Console.Write(_decimalArray[i] + ", ");
            Console.Write("]");
        }

        public void SetDecimalArray(decimal[] values) => _decimalArray = values;
        public void SetDecimalArray(uint position,decimal value) => _decimalArray[position] = value;
        public uint GetVectorCount() => _num_vec;

        public static VectorDecimal operator++(VectorDecimal v) 
        {
            for (uint i = 0; i < v._size; i++)
                v._decimalArray[i]++;
            return v;
        }
        public static VectorDecimal operator --(VectorDecimal v)
        {
            for (uint i = 0; i < v._size; i++)
                v._decimalArray[i]--;
            return v;
        }
        public static bool operator true(VectorDecimal v)
        {
            bool f = true;
            foreach (decimal value in v._decimalArray)
                if (value != 0)
                {
                    f = false;
                    break;
                    
                }
            return v._size != 0 || f == false;
        }
        public static bool operator false(VectorDecimal v)
        {
            bool f = true;
            foreach (decimal value in v._decimalArray)
                if (value != 0)
                {
                    f = false;
                    break;

                }
            return v._size == 0 || f != false;
        }
        public static bool operator!(VectorDecimal v)
        {
            if(v._size != 0)
                return true;
            else
                return false;
        }
        public static VectorDecimal operator~(VectorDecimal v)
        {
            for (uint i = 0; i < v._size; i++)
                v._decimalArray[i] = ~(int)v._decimalArray[i];
            return v;
        }
        public static VectorDecimal operator+(VectorDecimal a, VectorDecimal b)
        {
            for(int i = 0; i<a._size; i++)
            a._decimalArray[i] += b._decimalArray[i];
            return a;
        }
        public static VectorDecimal operator+(VectorDecimal v, decimal d)
        {
            for (int i = 0; i < v._size; i++)
                v._decimalArray[i] += d;
            return v; 
        }
        public static VectorDecimal operator-(VectorDecimal a, VectorDecimal b)
        {
            for (int i = 0; i < a._size; i++)
                a._decimalArray[i] -= b._decimalArray[i];
            return a;
        }
        public static VectorDecimal operator -(VectorDecimal v, decimal d)
        {
            for (int i = 0; i < v._size; i++)
                v._decimalArray[i] -= d;
            return v;
        }
        public static decimal operator *(VectorDecimal a, VectorDecimal b)
        {
            decimal prod = 0;
            for (int i = 0; i < a._size; i++)
               prod += a._decimalArray[i] * b._decimalArray[i];
            return prod;
        }
        public static VectorDecimal operator*(VectorDecimal v, decimal d)
        {
            for(int i = 0; i<v._size; i++)
                v._decimalArray[i]*=d;
            return v;
        }
        public static VectorDecimal operator /(VectorDecimal v, decimal d)
        {
            for (int i = 0; i < v._size; i++)
                v._decimalArray[i] /= d;
            return v;
        }
        public static VectorDecimal operator|(VectorDecimal a, VectorDecimal b)
        {
            for (int i = 0; i < a._size; i++)
                a._decimalArray[i] = (int)a._decimalArray[i] | (int)b._decimalArray[i];
            return a;
        }
        public static VectorDecimal operator &(VectorDecimal a, VectorDecimal b)
        {
            for (int i = 0; i < a._size; i++)
                a._decimalArray[i] = (int)a._decimalArray[i] & (int)b._decimalArray[i];
            return a;
        }
        public static VectorDecimal operator^(VectorDecimal a, VectorDecimal b)
        {
            for (int i = 0; i < a._size; i++)
                a._decimalArray[i] = (int)a._decimalArray[i] ^ (int)b._decimalArray[i];
            return a;
        }
        public static VectorDecimal operator ^(VectorDecimal a, byte d)
        {
            for (int i = 0; i < a._size; i++)
                a._decimalArray[i] = (int)a._decimalArray[i] ^ d;
            return a;
        }
        public static VectorDecimal operator <<(VectorDecimal a, int shift)
        {
            for (int i = 0; i < a._size; i++)
                a._decimalArray[i] = (int)a._decimalArray[i] << shift;
            return a;
        }
        public static VectorDecimal operator >>(VectorDecimal a, int shift)
        {
            for (int i = 0; i < a._size; i++)
                a._decimalArray[i] = (int)a._decimalArray[i] >> shift;
            return a;
        }
        public static bool operator ==(VectorDecimal a, VectorDecimal b)
        {
            bool f = true;
            for (int i = 0; i < a._size; i++)
                if(a._decimalArray[i] != b._decimalArray[i])
                {
                    f = false;
                    break;
                }
            return f;
        }
        public static bool operator !=(VectorDecimal a, VectorDecimal b)
        {
            bool f = true;
            for (int i = 0; i < a._size; i++)
                if (a._decimalArray[i] == b._decimalArray[i])
                {
                    f = false;
                    break;
                }
            return f;
        }
        public static bool operator >(VectorDecimal a, VectorDecimal b)
        {
            bool f = true;
            for (int i = 0; i < a._size; i++)
                if (a._decimalArray[i] < b._decimalArray[i])
                {
                    f = false;
                    break;
                }
            return f;
        }
        public static bool operator <(VectorDecimal a, VectorDecimal b)
        {
            bool f = true;
            for (int i = 0; i < a._size; i++)
                if (a._decimalArray[i] > b._decimalArray[i])
                {
                    f = false;
                    break;
                }
            return f;
        }
        public static bool operator >=(VectorDecimal a, VectorDecimal b)
        {
            bool f = true;
            for (int i = 0; i < a._size; i++)
                if (a._decimalArray[i] <= b._decimalArray[i])
                {
                    f = false;
                    break;
                }
            return f;
        }
        public static bool operator <=(VectorDecimal a, VectorDecimal b)
        {
            bool f = true;
            for (int i = 0; i < a._size; i++)
                if (a._decimalArray[i] >= b._decimalArray[i])
                {
                    f = false;
                    break;
                }
            return f;
        }

    }
}
