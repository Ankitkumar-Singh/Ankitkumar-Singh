$(function () {
    $("#checkAll").click(function () {
        $("input[name='departmentDelete']").attr("checked", this.checked);

        $("input[name='departmentDelete']").click(function () {
            if ($("input[name='departmentDelete']").length == $("input[name='departmentDelete']:checked").length) {
                $("#checkAll").attr("checked", "checked");
            }
            else {
                $("#checkAll").removeAttr("checked");
            }
        });

    });

    $("#btnSubmit").click(function () {
        var count = $("input[name='departmentDelete']:checked").length;
        if (count == 0) {
            alert("No rows selected to delete");
            return false;
        }
        else {
            return confirm(count + " row(s) will be deleted");
        }
    });
});