namespace SolidOperations;



// Example of Single Responsiblity Prinsiple (SRP)
// There are three SRP orcestrated (OrderValidator, OrderNotificationSender, OrderSaver) 
// by one class named "OrderProcessor" and called from a method named "Process". 
public class OrderProcessor
{
    private readonly OrderValidator orderValidator;
    private readonly IOrderSaver[] orderSaver;
    private readonly OrderNotificationSender orderNotificationSender;
    public OrderProcessor(OrderValidator orderValidator, IOrderSaver[] orderSaver, OrderNotificationSender orderNotificationSender)
    {
        this.orderValidator = orderValidator;
        this.orderSaver = orderSaver;
        this.orderNotificationSender = orderNotificationSender;
    }
    public void Process()
    {
        orderValidator.Validate();
        //foreach calling any save method in the "IOrderSaver" interface
        foreach(var method in orderSaver)
            
            method.Save(null);

        orderNotificationSender.SendNotification();
    }
}
public class OrderValidator
{
    public void Validate() {    }
}

// Add an interface for the Open/Closed Principle.
public interface IOrderSaver
{
    void Save(string order);
}
public interface IOrderDeleter
{
    int Delete(int id);
}

public interface IOrderReader
{
    string Read(int id); 
}
public class DbOrderSaver : IOrderSaver
{
    public void Save(string order) {    }
}
// The second method we can use our Save method because of the IOrderSaver interface.
public class CacheOrderSaver : IOrderSaver
{
        public void Save(string order) {    }
}

public class OrderNotificationSender
{
    public void SendNotification() {    }
}
