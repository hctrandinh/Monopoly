
# Monopoly  
  
## Presentation of project  
_***Monopoly***_ is a board game currently published by Hasbro. In the game, players roll two six-sided dice to move around the game board, buying and trading properties, and developing them with houses and hotels. Players collect rent from their opponents, with the goal being to drive them into bankruptcy. Money can also be gained or lost through Chance and Community Chest cards, and tax squares; players can end up in jail, which they cannot move from until they have met one of several conditions.  
  
Here we coded it with C# using some desing patterns.  
  
## Project overview  
  
The Game Board of the monopoly is composed of 40 boxes that has a different aim and properties.  
They could be jail, land or chance spots etc... None of them squares change during the game, the player is brought to visit most of them during the game, and can build his towns, pay taxes or pay others when he visits foreign owned box. We decided to create .txt files where we wrote all the informations about the different boxes (position on the board, effect etc..) for a code more readable and homogeneous.  
  

  
## Design pattern  ![image](https://drive.google.com/uc?export=view&id=1O8NUAbv2jCTR62zSdQ39pbBUrUBpdS6P)
### FACTORY  
For our project we used factory design for all the boxes. Since we had to create many, it was easier this way and a lot more readable. Also, we didn't need to put the parameters each time (position and name mostly).  
  
Most of our factory pattern were called in the Board.cs, the Gaming.cs. Indeed, we created a CaseFactory which was inherited by all of our box classes (Tax, Jail, Chance , Community etc...).  
This way when calling them to create the board and to position them, we just had to call the methods inherited.  
To access the informations with the Factory classes, we used a StreamReader to read the .txt file containing the informations then we attributed them in our GetCard() methods.  

```C#
class TaxeFactory : CasesFactory
    {
        private string name { get; set; }
        private int position { get; set; }
        private int price { get; set; }

        public override Case GetCase()
        {
            Case case_taxe = new Taxes(position, name, price);
            string line;
            // Read the file and display it line by line.  
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            System.IO.StreamReader file = new System.IO.StreamReader(dir + "/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Tax.txt");
            line = file.ReadLine();
            string[] words = line.Split(',');
            case_taxe = new Taxes(int.Parse(words[0]), words[1], int.Parse(words[2]));
            file.Close();
            return case_taxe;
        }
    }
    ```
### SINGLETON  
A singelton is a Creational design pattern , a singleton class should have some properties :  
  
It instanciates only once and should be globally accessible.  
  
That's why we decided to use it for the board, since only one can be created.  
  
Along with that, we used a lock so that if two people were to try and create a board at the same time, one of them would be "locked" outside the method and thus only one could be created.
```C#  
private static Board instance;//Singleton
        private static readonly object locker = new object();

        public static Board Instance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new Board();
                    }
                }
            }
            return instance;
        }
        ```
### OBSERVER  
  
The ***observer pattern*** is a software ***design pattern*** in which an object, called the subject, maintains a list of its dependents, called ***observers***, and notifies them automatically of any state changes, usually by calling one of their methods.  
We decided to use this one for the Bank, so that if any changes happens we could get notified.  
To do so, we created an observer, a concrete observer, the bank and what we called the concrete bank.  
  
The concrete bank inherites the Bank and is here to control the stocks.  
We created in the bank classes all the necessary methods for the observer, to be able to add, detach and notify them.  
The observer is here to make the updates while the concrete observer, inheriting the previous one, is associated to a player and will finally update him on the changes happening.  
```C#
 private List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer observer in _observers)
            {
                observer.Update(this);
            }
        }
        ```
  
## Conclusion  
  
While we didn't code the whole game as there are too many possibilities to cover, we went a lot further than what the subject suggested us to do. We used it to practice our design pattern and we worked rigourously on how to build the whole environment which could welcome design patterns. We also tried to have a clean and homogeneous code as much as we could. It was an interesting project, we are happy with what we did !