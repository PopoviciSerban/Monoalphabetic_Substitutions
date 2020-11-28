using System;

namespace Substitutii_monoalfabetice
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;
            int n;

            Console.WriteLine("1. Caesars Chiper - Give a string");
            s = Console.ReadLine();

            CaesarsChiper txt = new CaesarsChiper(s);

            txt.Encrypt();
            Console.WriteLine(@"Encrypted text: {0}", txt.ToString());

            txt.Decrypt();
            Console.WriteLine(@"Decrypted text: {0}", txt.ToString());

            Console.WriteLine("\n2. Caesars Chiper Generalised - Give a string");
            s = Console.ReadLine();

            Console.WriteLine("Give n (the number of shifts)");
            n = int.Parse(Console.ReadLine());

            CaesarsChiperGeneralised txt1 = new CaesarsChiperGeneralised(s, n);

            txt1.Encrypt();
            Console.WriteLine(@"Encrypted text: {0}", txt1.ToString());

            txt1.Decrypt();
            Console.WriteLine(@"Decrypted text: {0}", txt1.ToString());

            Console.WriteLine("\n3. ROT13 Chiper - Give a string");
            s = Console.ReadLine();

            ROT13 txt2 = new ROT13(s);

            txt2.Encrypt();
            Console.WriteLine(@"Encrypted text: {0}", txt2.ToString());

            txt2.Decrypt();
            Console.WriteLine(@"Decrypted text: {0}", txt2.ToString());

            Console.WriteLine("\n4. Monoalphabetic substitution - Give a string");
            s = Console.ReadLine();

            MonoalphabeticSubstitution txt3 = new MonoalphabeticSubstitution(s);

            txt3.Encrypt();
            Console.WriteLine(@"Encrypted text: {0}", txt3.ToString());

            txt3.Decrypt();
            Console.WriteLine(@"Decrypted text: {0}", txt3.ToString());

            Console.ReadKey();
        }
    }

    class AlgoritmSimetric
    {
        protected string Text { get; set; }
        protected int Key { get; set; }

        public AlgoritmSimetric()
        {
            this.Text = "Default Text";
            this.Key = 0;
        }

        public AlgoritmSimetric(string text) : this()
        {
            this.Text = text;
        }

        public AlgoritmSimetric(string text, int key): this(text)
        {
            this.Key = key;
        }

        public static char Chiper(char ch, int key)
        {
            if (!char.IsLetter(ch))
                return ch;
        
            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)(((((ch + (key % 26)) - d) % 26) + d));
        }

        public virtual void Encrypt()
        {
            string output = string.Empty;

            foreach (char ch in this.Text)
                output += AlgoritmSimetric.Chiper(ch, this.Key);

            this.Text = output;
        }

        public virtual void Decrypt()
        {
            string output = string.Empty;

            foreach (char ch in this.Text)
                output += AlgoritmSimetric.Chiper(ch, (26 - this.Key % 26));

            this.Text = output;
        }

        public override string ToString() => this.Text;
    }

    class CaesarsChiper : AlgoritmSimetric
    {
        public CaesarsChiper() : base()
        {
            this.Key = 3;
        }

        public CaesarsChiper(string text) : base(text)
        {
            this.Key = 3;
        }
    }

    class CaesarsChiperGeneralised : AlgoritmSimetric
    {
        public CaesarsChiperGeneralised() : base()
        {
            this.Key = 3;
        }

        public CaesarsChiperGeneralised(string text) : base(text)
        {
            this.Key = 3;
        }

        public CaesarsChiperGeneralised(string text, int key) : base(text, key)
        {
        }
    }

    class ROT13 : AlgoritmSimetric
    {
        public ROT13() : base()
        {
            this.Key = 13;
        }

        public ROT13(string text) : base(text)
        {
            this.Key = 13;
        }
    }

    class MonoalphabeticSubstitution : AlgoritmSimetric 
    {
        private int[] EncryptAlphabet = { 25, 4, 1, 17, 0, 18, 2, 3, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 19, 20, 21, 22, 23, 24 };
        private int[] DecryptAlphabet = { 4, 2, 6, 7, 1, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 3, 5, 20, 21, 22, 23, 24, 25, 0 };

        public MonoalphabeticSubstitution() : base()
        {
        }

        public MonoalphabeticSubstitution(string text) : base(text)
        {
        }

        public override void Encrypt()
        {
            string output = string.Empty;

            foreach (char ch in this.Text)
            {
                if (char.IsLetter(ch))
                {
                    char d = char.IsUpper(ch) ? 'A' : 'a';
                output += (char)(EncryptAlphabet[ch - d] + d);
                }
                else output += ch;
            }

            this.Text = output;
        }

        public override void Decrypt()
        {
            string output = string.Empty;

            foreach (char ch in this.Text)
            {
                if (char.IsLetter(ch))
                {
                    char d = char.IsUpper(ch) ? 'A' : 'a';
                    output += (char)(DecryptAlphabet[ch - d] + d);
                }
                else output += ch;
            }

            this.Text = output;
        }
    }
}
