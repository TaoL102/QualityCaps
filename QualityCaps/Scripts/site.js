$(function () {
  
});

// Function: DelTable
function funDelTable() {
    $("#cartTableRowTitle").fadeOut('slow');
    $("#cartTableRows").remove("#cartTableRowTitle");
    $("#cartTable").fadeOut('slow');

    // Append info:
    $("#cartTableContainer").empty();
    $("#cartTableContainer").prepend('<div class="text-center"><p>Shopping cart is empty</p></div>').fadeIn('slow');
};

// Function: DelTableRow
function funDelTableRow(productID, colorID) {
    // Fade out current row
    $("#" + productID + colorID).fadeOut('slow');
    $("#cartTableRows").remove("#" + productID + colorID);

    // If this is the lase row , fade out table as well
    if ($("#cartTableRows tr:visible").length === 1) {
        funDelTable();
    }
};

// Function: ShowFailureNotification
function funShowFailureNotification(message) {
    $("#notification").append('<div class="alert alert-danger"><div class="container-fluid"><div class="alert-icon"><i class="material-icons">error_outline</i></div><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true"><i class="material-icons"></i></span></button><div></div>' + message + '.</div></div>'
).children(':last').hide().fadeIn().delay(4000).fadeOut(1000);
}

// Function: ShowSuccessNotification
function funShowSuccessNotification(message) {
    $("#notification").append('<div class="alert alert-success"><div class="container-fluid"><div class="alert-icon"><i class="material-icons">check</i></div><button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true"><i class="material-icons"></i></span></button><div></div>' + message + '.</div></div>'
).children(':last').hide().fadeIn().delay(4000).fadeOut(1000);
}

// Function: Cart_Icon_Init
function funCart_Icon_Init(url) {
    $.ajax({
        type: "POST",
        url: url,
    }).done(function (data) {
        console.log(data);
        $("#cartTotalQuantity").text(data);
    }).fail(function () {
        funShowFailureNotification("Unable to update shopping cart info due to server connection failure");
    });
}

// Function: Cart_Icon_Click
function funCart_Icon_Click(url) {
    $.ajax({
        type: "POST",
        url: url
    })
                       .done(function (partialViewResult) {
                           $("#cartTableContainer").html(partialViewResult);
                       });
}

// Function: Add_To_Cart_Button_Click
function funAdd_To_Cart_Button_Click(url,object) {
    // Get data content (product id and color id)
    var dataContent = object.getAttribute('data-content');
    // Convert to JSON format
    dataContent = JSON.parse(dataContent);

    var productID = dataContent.ProductID;
    var colorID = dataContent.ColorID;
    var productName= dataContent.ProductName;
    var productColor = dataContent.ProductColor;

    if (productID != '' && colorID != '') {
        // Perform the ajax post
        funAddItemToCart(productID, colorID, productName, productColor,url);
    };
}

// Function: AddItemToCart
function funAddItemToCart(productID, colorID, productName, productColor,url) {
    // Use ajax to Handel session data
    $.ajax({
        type: "POST",
        url: url,
        data: { productID: productID, colorID: colorID },
    })
                           .done(function (data) {
                               // Update Cart Icon quantity
                               $("#cartTotalQuantity").text(data);

                               // Notification
                               funShowSuccessNotification(productName+" "+productColor+" added to shopping cart");
                           })
                           .fail(function () {
                               funShowFailureNotification("Unable to add item to cart due to server connection failure");
                           });
}

// Function: Inc_Dec_Button_Click
function funInc_Dec_Button_Click(url,object) {
    // Get data content (product id and color id)
    var dataContent = object.getAttribute('data-content');
    // Convert to JSON format
    dataContent = JSON.parse(dataContent);

    var productID = dataContent.ProductID;
    var colorID = dataContent.ColorID;

    if (productID !== '' && colorID !== '') {
        // Check if this button is Inc button or Dec button
        // Change the display quantity (quantity label)
        // Get modified product's quantity
        var modifiedQty = $("#lbl_Qty_" + productID + colorID).text();

        if (object.getAttribute('data-id') === "Inc") {
            modifiedQty++;
        }
        else if (object.getAttribute('data-id') === "Dec") {
            if (modifiedQty !== "0") {
                modifiedQty--;
            }
        }

        funModifyCartItemQuantity(productID, colorID, modifiedQty, url);
    }
}

// Function: ModifyCartItemQuantity
function funModifyCartItemQuantity(productID, colorID, modifiedQty, url) {
    // Use ajax to Handel session data
    $.ajax({
        type: "POST",
        url: url,
        data: { productID: productID, colorID: colorID, quantity: modifiedQty },
    })
        .done(function (data) {
            if (modifiedQty <= 0) {
                funDelTableRow(productID, colorID);
            }


            // Get return data and parse to json
            data = JSON.parse(data);
            var cartTotalQty = data.CartTotalQty;
            var cartSubTotal = data.CartSubTotal;
            var cartGst = data.CartGst;
            var cartTotal = data.CartTotal;
            var itemTotal = data.ItemTotal;

            // change Subtotal,gst,total
            $("#lbl_Qty_" + productID + colorID).text(modifiedQty);
            $("#cart_subtotal").text(cartSubTotal);
            $("#cart_gst").text(cartGst);
            $("#cart_total").text(cartTotal);
            $("#cartTotalQuantity").text(cartTotalQty);
            $("#td_item_total_" + productID + colorID).text(itemTotal);
        })
        .fail(function () {
            funShowFailureNotification("Unable to change quantity due to server connection failure.");
        });
}


// Function: Clear_Cart_Button_Click
function funClear_Cart_Button_Click(url) {
    $.ajax({
        type: "POST",
        url: url,
    }).done(function (data) {
        funDelTable();

        // Update the shopping cart icon
        $("#cartTotalQuantity").text(data);

    }).fail(function () {
        funShowFailureNotification("Unable to clear cart due to server connection failure.");
    });
}

// Function: Product_Detail_Color_Radio_Button_Click
function funProduct_Detail_Color_Radio_Button_Click(productID, colorID, actionUrl,imgDir) {
   
    // Perform the ajax post
    $.ajax({
        type: "POST",
        url: actionUrl,
        data:  { productID: productID, colorID: colorID },
    }).done(function(data) {
        
        $("#productPic").attr("src", imgDir + '/' + data);

    }).fail(function()  {
        funShowFailureNotification("Unable to load product picture due to server connection failure.");
    });
}

// Function: Product_Detail_Click
function funProduct_Detail_Link_Click(object) {
    // Get data content (product id and color id)
    var dataUrl = object.getAttribute('data-url');
    console.log(dataUrl);
    $.ajax({
        type: "POST",
        url: dataUrl
    })
      .done(function (partialViewResult) {
          $("#productDetailContainer").html(partialViewResult);
          $("#productDetailModal").modal('show');

      });
}

