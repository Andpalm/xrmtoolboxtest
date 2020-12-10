if (typeof (AccountForm) == "undefined")
    AccountForm = {};

AccountForm.Functions = {
    industryOnChange: function (context) {
        var formContext = context.getFormContext();
        var text = formContext.getAttribute("industrycode").getText();
        formContext.getAttribute("description").setValue(text);
    },
}
