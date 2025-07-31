# Software Center 

They maintain the list of supported software for our company.

We are building them an API.

## Vendors

We have arrangements with vendors. Each vendor has:

- And ID we assign - 99.999% this is immutable.
- A Name - Nope. Immutable
- A Website URL - Immutable
- A Point of Contact - This will change over time.
  - Name
  - Email
  - Phone Number

Vendors have a set of software they provide that we support.

## Catalog Items

Catalog items are instances of software a vendor provides.

A catalog item has:
- An ID we assign
- A vendor the item is associated with
- The name of the software item
- A description
- A version number (we prefer SEMVER, but not all vendors use it)

"Http Requests Must Contain All the Data Server needs to Fullfill the Request" - a rule. Just how it is

 - Http Requests can put data in the following locations:
  - The URL - including routinf parameters(e.g. GET /vendors/{id:guid}).
    - "Query String Parameters" - GET /vendors?addedBy=sue@aol.com
  - Headers
    - Authorization this is(in API) always how we answer the "who" question.( GET POST PUT DELETE)
  - You cansend a "body" (entity).(POST PU)


Note - One catalog item may have several versions. Each is it's own item.
Design:
  - What is the resource
  - What is the represantation
  - What is the the method

```http
POST /catalog-items
Content-Type: application/json  

{
  "name": "Visual Studio Code"
  "version"
}

## Use Cases

The Software Center needs a way for managers to add vendors. Normal members of the team cannot add vendors.
Software Center team members may add catalog items to a vendor.
Software Center team members may add versions of catalog items.
Software Center may deprecate a catalog items. (effectively retiring them, so they don't show up on the catalog)

Any employee in the company can use our API to get a full list of the software catalog we currently support.


## "Candidate" Resources

- vendors
- items


- roles
    - software center managers
    - software center team members
    - employees

 
