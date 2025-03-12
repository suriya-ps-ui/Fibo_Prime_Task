using System;
using System.Data;
class Program{
    public static int fibo(int num){
        if(num==0){
            return 0;
        }
        if(num==1){
            return 1;
        }
        return fibo(num-1)+fibo(num-2);
    }
    public static List<int> fiboSeries(int n){
        List<int> fbSeries=new List<int>();
        for(int i=0;i<n;i++){
            fbSeries.Add(fibo(i));
        }
        return fbSeries;
    }
    public static Boolean isPrime(int num){
        bool prime=true;
        if(num==2 || num==3){
            return prime;
        }
        if(num%2==0 || num%3==0){
            return !prime;
        }
        for(int i=5;i<=Math.Sqrt(num);i+=2){
            if(num%i==0){
                prime=false;
                break;
            }
        }
        return prime;
    }
    public static List<int> primeInRange(int n){
        List<int> primes=new List<int>();
        for(int i=2;i<=n;i++){
            if(isPrime(i)){
                primes.Add(i);
            }
        }
        return primes;
    }
    public static List<int> primeForLength(int n){
        List<int> primes=new List<int>();
        int num=2;
        while(primes.Count<n){
            if(isPrime(num)){
                primes.Add(num);
            }
            num++;
        }
        return primes;
    }
    static void Main(string[] args){
        int primeLen;
        Console.WriteLine("Enter  length for Prime Numbers:");
        primeLen=Convert.ToInt32(Console.ReadLine());
        List<int> primes=primeForLength(primeLen);
        int[] fibArray=primes.ToArray();
        for(int i=0;i<fibArray.Length;i++){
            fibArray[i]=fibo(fibArray[i]);
        }
        Console.Write($"Fibonacci Number for First {primeLen} Prime Numbers\n");
        Console.Write("[");
        Console.Write(string.Join(",",fibArray));
        Console.Write("]");
    }
}