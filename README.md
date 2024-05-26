# Event Automation and Customer Relationship Manager Application
This document serves as a guide to the data types that serve as the foundation for the application. 

## Address
An address is defined with the following properties:
```
AddressObject {
    AddressUse 
    AddressType
    AddressLine1
    AddressLine2
    City
    State
    Zip
    Latitude
    Longitude
}
```
An address can belong to multiple different other classes. When used in conjunction with a Venue, and non-null Coordinates, it can be used as way of verifying geographic proximity. As such, this can be used to ensure that guests cannot check in to an event unless they are physically present.
The `AddressUse` and `AddressType` properties can be used to further information as to the nature in which it is associated to a class. There many be specific instances where and `Organization` or a `Venue` may have multiple valid addresses. Note: The use of AddressUse and AddressType is not appropriate in the case of a Venue with multiple different locations. Please refer to the `Organization` class for the proper modeling of such an association.

## Venue
A venue is defined as a location in which an `Event` may occur. This system allows for the existence of a venue in the context of a "Sales Pipeline" through the use of properties like `LeadStatus`, and `KeyPeople`.
The `Venue` object implements the `IOrganization` interface, and derives the following functions, which are intended to be used for managing a sales pipeline.:
    - `GetKeyPersonnel()`
    - `AddPerson()`
    - `RemovePerson()`
These Venue object has the following properties:
```
Venue {
    Name
    Address
    Type
    KeyPeople
    Status
}
```
It is appropriate to only provide a `Name` and `Address` for a Venue, when inputting data. Every `Event` is required to be associated with a `Venue`, in order to provide a user relevant details on the Application frontend.

## Organization
An Organization can be used for two purposes: 
- To enter relevant Company information
- To associate a `Venue` that has multiple, and materially different, locations. For instance, a Venue which has a physical location, but a different mailing address is not materially different, and the two addresses may appropriately be differentiated using the `AddressUse` and `AddressType` properties. However, two venues which operate under the same corporate structure but have two different physical locations, should be assigned to an `Organization` additionally.

An `Event` cannot be assigned to an organization. The organization class is most appropriate providers of services tangential to the hosting operations of an event: Caterers, Stores, Restaurants, Sponsors, Contractors, Entertainers, DJs, Transportation, Exhibitors.

```
Organization {
    OrganizationName
    OrganizationDescription
    VenuesList
}
```

## Event
An Event is defined as a gathering of people, for a specific purpose, at a specific time and place. The `Event` object has the following properties:
```
Event {
    Name
    Description
    CreatedAt
    EventDate
    RequireTickets
    EventVenue
    Address (Deprecated after Version 2.0)
    EventHost
    EventCoHosts
}
```
*Please note that I still need to flesh out all the details regarding the different Event settings*

Tangential to the `Event` object is `EventSettings`, which provides other settings related to the functionality of an Event, as well as record keeping. The `EventSettings` object has a multitude of properties including:
- Date and Time Information: If the event has a more complicated schedule, this can be used to provide a more detailed breakdown of the event. (`StartDate`, `StartTime`, `EndDate`, `EndTime`, `TimeZone`, `IsMultiDay`, `IsRecurring`, `RecurringPattern`, `RecurrenceDescription`, `RecurrenceEndDate`, `RecurenceException`, `IsAllDay`)
- Access Control and Privacy Settings: This can be used to determine who can see the event, and who can interact with it. (`IsPrivate`, `IsVisible`, `IsPasswordProtected`, `Password`)
- Detailed Pricing and Ticketing Settings ()
- Event Status (`IsCancelled`, `IsPostponed`, `IsRescheduled`, `IsSoldOut`)