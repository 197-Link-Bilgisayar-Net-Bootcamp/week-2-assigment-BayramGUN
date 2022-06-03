//Liskov substitution


// All cars have a Engine start operation. 
public class Car
{
    public void StartEngine(){  }
}

// Electric cars should be charging they cannot GetOil
public class ElectricCar : Car
{
    public void ChargeBattery(){  }
}

// Diesel cars cannot charge battery but they shuold get oil
public class DieselCar : Car
{
    public void GetOil() {  }
}

// Ford is a diesel car:
public class Ford : DieselCar
{

}
// Tesla is a Electric Car:
public class Tesla : ElectricCar
{

}