using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.DAL
{
    public class DataBaseManagment
    {
        //create an object of SingleObject
        private DataBaseManagment() { }

        // The Singleton's instance is stored in a static field. There there are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        private static DataBaseManagment _instance;

        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        public static DataBaseManagment GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataBaseManagment();
            }
            return _instance;
        }

        // Finally, any singleton should define some business logic, which can
        // be executed on its instance.
        public void someBusinessLogic()
        {
            // ...
        }
    }
}
