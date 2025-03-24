using System;
using System.Data;
using System.Data.SqlTypes;
using System.Linq.Expressions;
using System.Net.Http.Headers;
class Program{
    //Method to find fibo number
    public static int fibo(int num){
        if(num==0){
            return 0;
        }
        if(num==1){
            return 1;
        }
        return fibo(num-1)+fibo(num-2);
    }
    //Method to get fibo series of for n numbers
    public static List<int> fiboSeries(int n){
        List<int> fbSeries=new List<int>();
        for(int i=0;i<n;i++){
            fbSeries.Add(fibo(i));
        }
        return fbSeries;
    }
    //Method to find wheather given number is prime or not
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
    //Method to get prime numbers from range 2 to n
    public static List<int> primeInRange(int n){
        List<int> primes=new List<int>();
        for(int i=2;i<=n;i++){
            if(isPrime(i)){
                primes.Add(i);
            }
        }
        return primes;
    }
    //Method to get n number of prime numbers
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
    public static int validate(){
        Console.WriteLine("Enter  length for Prime Numbers:");
        retry:
        try{
            return Convert.ToInt32(Console.ReadLine()); 
        }catch(Exception ex){
            System.Console.WriteLine("Enter integer number:"+ex.Message);
            goto retry;
        }
    }
    static void Main(string[] args){
        int primeLen;
        primeLen=validate();//Getting n number of prime numbers
        List<int> primes=primeForLength(primeLen);
        int[] fibArray=primes.ToArray();//Converting list to an array
        //Converting prime numbers to its respective fibo number
        for(int i=0;i<fibArray.Length;i++){
            fibArray[i]=fibo(fibArray[i]);
        }
        //Print all fibo numbers
        Console.Write($"Fibonacci Number for First {primeLen} Prime Numbers\n");
        Console.Write("[");
        Console.Write(string.Join(",",fibArray));
        Console.Write("]");
    }
}