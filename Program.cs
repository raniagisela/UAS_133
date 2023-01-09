using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_133
{
    class Node
    {
        public int nomorBuku;
        public string judulBuku;
        public string namaPengarang;
        public int tahunTerbit;
        public Node next;
    }

    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void addNote()
        {
            int nomorBuku;
            string judulBuku;
            string namaPengarang;
            int tahunTerbit;
            Console.Write("\nMasukkan nomor buku: ");
            nomorBuku = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan judul buku: ");
            judulBuku = Console.ReadLine();
            Console.Write("\nMasukkan nama pengarang: ");
            namaPengarang = Console.ReadLine();
            Console.Write("\nMasukkan tahun terbit: ");
            tahunTerbit = Convert.ToInt32(Console.ReadLine());
            Node newnode = new Node();
            newnode.nomorBuku = nomorBuku;
            newnode.judulBuku = judulBuku;
            newnode.namaPengarang = namaPengarang;
            newnode.tahunTerbit = tahunTerbit;

            if (START == null || nomorBuku <= START.nomorBuku)
            {
                if ((START != null) && (nomorBuku == START.nomorBuku))
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (nomorBuku >= current.nomorBuku))
            {
                if (nomorBuku == current.nomorBuku)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }
                previous = current;
                current = current.next;
            }

            newnode.next = current;
            previous.next = newnode;
        }

        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (rollNo != current.tahunTerbit))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }
        public void Traverse()
        {
            if (ListEmpty())
                Console.WriteLine("\nData buku yang ter-list: ");
            else
            {
                Console.WriteLine("\nData buku yang ter-list: ");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)
                    Console.Write(currentNode.nomorBuku + " "+ currentNode.judulBuku + 
                        " " + currentNode.namaPengarang + " " +currentNode.tahunTerbit + "\n");
                Console.WriteLine();
            }
        }
        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. Masukkan data buku ke list");
                    Console.WriteLine("2. Hapus data buku dari list");
                    Console.WriteLine("3. Tampilkan data buku dari list");
                    Console.WriteLine("4. Mencari data buku dari list");
                    Console.WriteLine("5. EXIT");
                    Console.Write("\nEnter your choice (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;

                        case '2':
                            {
                                if (obj.ListEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.WriteLine("Masukkan tahun terbit " +
                                    " dari buku yang ingin dihapus: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("\n Record not found.");
                                else
                                    Console.WriteLine("Buku dari tahun terbit " +

                                        +rollNo + " terhapus");
                            }
                            break;
                        case '3':
                            {
                                obj.Traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan tahun terbit " +
                                    "dari buku yang ingin dicari: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nRecord not found.");
                                else
                                {
                                    Console.WriteLine("\nTahun Terbit: " + current.tahunTerbit);
                                    Console.WriteLine("\nJudul Buku: " + current.judulBuku);
                                }
                            }
                            break;

                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid Option");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCheck for the value enterd");
                }
            }
        }
    }
}

//2. Algorithm Single Linked List 
//3. PUSH dan POP
//4. insert dan delete
//5. a. 5
//   b. Dengan cara preoder traversal
//      -diawali dari akar
//      -membaca dengan melintasi dari kiri subtree
//      -membaca dengan melintasi dari kanan subtree
//      preoder traversal = 25 20 10 5 1 22 12 8 15 36 30 28 40 38 48 45 50