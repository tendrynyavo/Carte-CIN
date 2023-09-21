package com.foncier;

import java.rmi.RemoteException;
import javax.ejb.*;

public interface Demo extends EJBObject {

   // NB this simple example does not even do a

  // lookup in the database

  public String demoSelect() throws RemoteException;

}