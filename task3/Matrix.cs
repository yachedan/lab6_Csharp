using System;

namespace task3
{
       class MatrixDecimal
    {
        private decimal[,] _decimalArray;
        private uint _n,_m;
        private int _codeError;
        private static uint _num_m;

        public decimal[,] DecimalArray {get { return _decimalArray;} set { _decimalArray = value;}}
        public uint SizeN {get {return _n;}}
        public uint SizeM { get { return _m; } }
        public int CodeError {get{return _codeError;} set{_codeError = value;}}

        public decimal this[uint i,uint j]
        {
            get
            {
                if (i < _n && j < _m)
                    return _decimalArray[i,j];
                else
                    return 0;
            }
            set
            {
                if (i < _n && j < _m)
                    _decimalArray[i,j] = value;
                else
                    _codeError = -1;
            }
        }
        public decimal this[uint k]
        {
            get
            {
                uint i = k/_m;
                uint j = k%_m;
                if (i < _n && j < _m)
                    return _decimalArray[i, j];
                else
                    return 0;
            }
            set
            {
                uint i = k / _m;
                uint j = k % _m;
                if (i < _n && j < _m)
                    _decimalArray[i, j] = value;
                else
                    _codeError = -1;
            }
        }

        public MatrixDecimal()
        {
            _decimalArray = new decimal[1,1];
            _decimalArray[0,0] = 0;
            _n = 1;
            _m = 1;
            _codeError = 0;
            _num_m++;
        }
        public MatrixDecimal(uint n, uint m)
        {
            _n = n;
            _m = m;
            _decimalArray = new decimal[n,m];
            for (int i = 0; i < n; i++)
                for(int j = 0; j<m; j++)
                    _decimalArray[i,j] = 0;
            _codeError = 0;
            _num_m++;
        }
        public MatrixDecimal(uint n,uint m, decimal value)
        {
            _n = n;
            _m = m;
            _decimalArray = new decimal[n,m];
            for (int i = 0; i < n; i++)
                for(int j = 0; j<m; j++)
                    _decimalArray[i,j] = value;
            _codeError = 0;
            _num_m++;
        }

        ~MatrixDecimal() => Console.WriteLine($"Destructor is executing");

        public void SetMatrix()
        {
            Console.WriteLine("Input decimals: ");
            decimal test = 0;
            for (int i = 0; i < _n; i++)
            {
                for(int j = 0; j < _m; j++)
                {
                    Console.Write("Index "+i+" "+j+": ");
                    while(!Decimal.TryParse(Console.ReadLine(), out test))
                    {
                        Console.Write("Wrong decimal! Try again: ");
                    }
                    _decimalArray[i,j] = Convert.ToDecimal(test);
                }
            }

        }
        public void GetMatrix()
        {
            Console.WriteLine("Matrix: ");
            for(int i = 0; i < _n; i++)
            {
                for(int j = 0; j < _m; j++)
                    Console.Write("{0,-10}",_decimalArray[i,j]);
                Console.WriteLine();
            }
        }
        public void SetDecimalArray(decimal[,] values) => _decimalArray = values;
        public void SetDecimalArray(uint n,uint m, decimal value) => _decimalArray[n,m] = value;
        public uint GetMatrixCount() => _num_m;
        public static MatrixDecimal operator ++(MatrixDecimal x)
        {
            for (uint i = 0; i < x._n; i++)
                for(uint j = 0; j < x._m; j++)
                    x._decimalArray[i,j]++;
            return x;
        }
        public static MatrixDecimal operator --(MatrixDecimal x)
        {
            for (uint i = 0; i < x._n; i++)
                for (uint j = 0; j < x._m; j++)
                    x._decimalArray[i, j]--;
            return x;
        }
        public static bool operator true(MatrixDecimal x)
        {
            bool f = true;
            foreach (decimal value in x._decimalArray)
                if (value != 0)
                {
                    f = false;
                    break;

                }
            return (x._n != 0 && x._m != 0) || f == false;
        }
        public static bool operator false(MatrixDecimal x)
        {
            bool f = true;
            foreach (decimal value in x._decimalArray)
                if (value != 0)
                {
                    f = false;
                    break;

                }
            return (x._n == 0 && x._m == 0) || f != false;
        }
        public static bool operator !(MatrixDecimal x)
        {
            if (x._n != 0 && x._m != 0)
                return true;
            else
                return false;
        }
        public static MatrixDecimal operator ~(MatrixDecimal x)
        {
            for (uint i = 0; i < x._n; i++)
                for(uint j = 0; j < x._m; j++)
                    x._decimalArray[i,j] = ~(int)x._decimalArray[i,j];
            return x;
        }
        public static MatrixDecimal operator +(MatrixDecimal a, MatrixDecimal b)
        {
            uint n;
            uint m;
            if (a._n < b._n)
                n = a._n;
            else
                n = b._n;
            if (a._m > b._m)
                m = a._m;
            else
                m = b._m;
            for (int i = 0; i < n; i++)
                for(int j = 0; j < m; j++)
                    a._decimalArray[i,j] += b._decimalArray[i,j];
            return a;
        }
        public static MatrixDecimal operator +(MatrixDecimal x, decimal d)
        {
            for (int i = 0; i < x._n; i++)
                for(int j = 0; j < x._m; j++)
                    x._decimalArray[i,j] += d;
            return x;
        }
        public static MatrixDecimal operator -(MatrixDecimal a, MatrixDecimal b)
        {
            uint n;
            uint m;
            if (a._n < b._n)
                n = a._n;
            else
                n = b._n;
            if (a._m > b._m)
                m = a._m;
            else
                m = b._m;
            for (int i = 0; i < n; i++)
                for(int j = 0; j < m; j++)
                    a._decimalArray[i,j] -= b._decimalArray[i,j];
            return a;
        }
        public static MatrixDecimal operator -(MatrixDecimal x, decimal d)
        {
            for (int i = 0; i < x._n; i++)
                for(int j = 0; j < x._m; j++)
                    x._decimalArray[i,j] -= d;
            return x;
        }
        public static MatrixDecimal operator *(MatrixDecimal a, MatrixDecimal b)
        {
            uint n;
            uint m;
            if (a._n < b._n)
                n = a._n;
            else
                n = b._n;
            if (a._m > b._m)
                m = a._m;
            else
                m = b._m;
            for (int i = 0; i < n; i++)
                for(int j = 0; j < m; j++)
                    a._decimalArray[i,j] *= b._decimalArray[i,j];
            return a;
        }
        public static MatrixDecimal operator *(MatrixDecimal x, decimal d)
        {
            for (int i = 0; i < x._n; i++)
                for(int j = 0; j < x._m; j++)
                    x._decimalArray[i, j] *= d;

            return x;
        }
        public static MatrixDecimal operator *(MatrixDecimal x, VectorDecimal v)
        {
            uint size = 0;
            if (x._n < v.Size)
                size = x._n;
            else
                size = v.Size;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < x._m; j++)
                    x._decimalArray[i, j] *= v.DecimalArray[i];
            return x;
        }
        public static MatrixDecimal operator /(MatrixDecimal a, MatrixDecimal b)
        {
            uint n;
            uint m;
            if (a._n < b._n)
                n = a._n;
            else
                n = b._n;
            if (a._m > b._m)
                m = a._m;
            else
                m = b._m;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a._decimalArray[i, j] /= b._decimalArray[i, j];
            return a;
        }
        public static MatrixDecimal operator /(MatrixDecimal x, decimal f)
        {
            for (int i = 0; i < x._n; i++)
                for (int j = 0; j < x._m; j++)
                    x._decimalArray[i, j] = x._decimalArray[i,j]/f;
            return x;
        }
        public static MatrixDecimal operator %(MatrixDecimal a, MatrixDecimal b)
        {
            uint n;
            uint m;
            if (a._n < b._n)
                n = a._n;
            else
                n = b._n;
            if (a._m > b._m)
                m = a._m;
            else
                m = b._m;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a._decimalArray[i, j] %= b._decimalArray[i, j];
            return a;
        }
        public static MatrixDecimal operator %(MatrixDecimal x, uint u)
        {
            for (int i = 0; i < x._n; i++)
                for (int j = 0; j < x._m; j++)
                    x._decimalArray[i, j] = x._decimalArray[i, j] % u;
            return x;
        }
        public static MatrixDecimal operator |(MatrixDecimal a, MatrixDecimal b)
        {
            uint n;
            uint m;
            if (a._n < b._n)
                n = a._n;
            else
                n = b._n;
            if (a._m > b._m)
                m = a._m;
            else
                m = b._m;
            for (int i = 0; i < n; i++)
                for(int j = 0; j < m; j++)
                    a._decimalArray[i,j] = (int)a._decimalArray[i,j] | (int)b._decimalArray[i,j];
            return a;
        }
        public static MatrixDecimal operator |(MatrixDecimal x, byte u)
        {
            for (int i = 0; i < x._n; i++)
                for (int j = 0; j < x._m; j++)
                    x._decimalArray[i, j] = (int)x._decimalArray[i, j] | u;
            return x;
        }
        public static MatrixDecimal operator ^(MatrixDecimal a, MatrixDecimal b)
        {
            uint n;
            uint m;
            if (a._n < b._n)
                n = a._n;
            else
                n = b._n;
            if (a._m > b._m)
                m = a._m;
            else
                m = b._m;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a._decimalArray[i, j] = (int)a._decimalArray[i, j] ^(int)b._decimalArray[i, j];
            return a;
        }
        public static MatrixDecimal operator ^(MatrixDecimal x, byte u)
        {
            for (int i = 0; i < x._n; i++)
                for (int j = 0; j < x._m; j++)
                    x._decimalArray[i, j] = (int)x._decimalArray[i, j] ^ u;
            return x;
        }
        public static MatrixDecimal operator <<(MatrixDecimal x, int u)
        {
            for (int i = 0; i < x._n; i++)
                for (int j = 0; j < x._m; j++)
                    x._decimalArray[i, j] = (int)x._decimalArray[i, j] << u;
            return x;
        }
        public static MatrixDecimal operator >>(MatrixDecimal x, int u)
        {
            for (int i = 0; i < x._n; i++)
                for (int j = 0; j < x._m; j++)
                    x._decimalArray[i, j] = (int)x._decimalArray[i, j] >> u;
            return x;
        }
        public static bool operator ==(MatrixDecimal a, MatrixDecimal b)
        {
            if (a._n != b._n || a._m != b._m)
                return false;
            bool f = true;
            for (int i = 0; i < a._n; i++)
            {
                for(int j = 0; j < a._m; j++)
                    if (a._decimalArray[i,j] != b._decimalArray[i,j])
                    {
                        f = false;
                        break;
                    }
                if(!f) break;
            }
            return f;
        }
        public static bool operator !=(MatrixDecimal a, MatrixDecimal b)
        {
            if (a._n != b._n || a._m != b._m)
                return true;
            bool f = true;
            for (int i = 0; i < a._n; i++)
            {
                for (int j = 0; j < a._m; j++)
                    if (a._decimalArray[i, j] == b._decimalArray[i, j])
                    {
                        f = false;
                        break;
                    }
                if (!f) break;
            }
            return f;
        }
        public static bool operator >(MatrixDecimal a, MatrixDecimal b)
        {
            if (a._n != b._n || a._m != b._m)
                return false;
            bool f = true;
            for (int i = 0; i < a._n; i++)
            {
                for (int j = 0; j < a._m; j++)
                    if (a._decimalArray[i, j] < b._decimalArray[i, j])
                    {
                        f = false;
                        break;
                    }
                if (!f) break;
            }
            return f;
        }
        public static bool operator <(MatrixDecimal a, MatrixDecimal b)
        {
            if (a._n != b._n || a._m != b._m)
                return false;
            bool f = true;
            for (int i = 0; i < a._n; i++)
            {
                for (int j = 0; j < a._m; j++)
                    if (a._decimalArray[i, j] > b._decimalArray[i, j])
                    {
                        f = false;
                        break;
                    }
                if (!f) break;
            }
            return f;
        }
        public static bool operator >=(MatrixDecimal a, MatrixDecimal b)
        {
            if (a._n != b._n || a._m != b._m)
                return false;
            bool f = true;
            for (int i = 0; i < a._n; i++)
            {
                for (int j = 0; j < a._m; j++)
                    if (a._decimalArray[i, j] <= b._decimalArray[i, j])
                    {
                        f = false;
                        break;
                    }
                if (!f) break;
            }
            return f;
        }
        public static bool operator <=(MatrixDecimal a, MatrixDecimal b)
        {
            if (a._n != b._n || a._m != b._m)
                return false;
            bool f = true;
            for (int i = 0; i < a._n; i++)
            {
                for (int j = 0; j < a._m; j++)
                    if (a._decimalArray[i, j] >= b._decimalArray[i, j])
                    {
                        f = false;
                        break;
                    }
                if (!f) break;
            }
            return f;
        }
        public override string ToString()
        {
            string result ="";
            result += "Matrix: \n";
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _m; j++)
                    result += String.Format("{0,-10}",_decimalArray[i, j]);
                result += "\n";
            }
            return result;
        }

        
    }
}
