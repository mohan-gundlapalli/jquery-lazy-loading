
// Logic for lazy loading.
$(function () {
    window.currentPage = 1;
    window.pageLoading = false;
    $(window).scroll(function () {

        if (window.pageLoading) {
            return; // Let the current page data finish loading.
        }

        var position = $(window).scrollTop();
        var bottom = $(document).height() - $(window).height();

        if (position + 50 >= bottom) {

            window.currentPage = window.currentPage + 1;
            window.pageLoading = true;

            $('div.page-loader').css({ display: 'flex' });

            $.ajax({
                url: 'Home/GetAccounts',
                type: 'get',
                data: { pageNo: window.currentPage },
                success: function (response) {
                    $("table#accounts-table tbody").append(response);

                    window.pageLoading = false;
                    $('div.page-loader').css({ display: 'none' });

                }
            });
        }

    });
})