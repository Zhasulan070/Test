<template>
  <div class="tab">
    <div class="tab-wrapper">
      <div
          class="tab-items"
          v-for="(item, i) in tabs"
          :key="i"
          :class="{ active: active.id === item.id }"
           @click="activate(item)" counting="false"
      >
        {{ item.name }} {{ counting ? `(${count})` : "" }}
      </div>
    </div>
  </div>
</template>
<script> export default {
  data() {
    return { activeHistory: false, active: null,};
  },
  props: {
    count: {type: Number, default: 0},
    tabs: {type: Array, default: () => [],},
    counting: {type: Boolean, default: false}
  },
  methods: {
    activate(item) {
      this.active = item;
      this.$emit('clicked', item);
    },
  },
  created: function () {
    this.active = this.tabs.length > 0 ? this.tabs[0] : null;
  },
}; </script>
<style lang="scss" scoped>.tab {
  &-wrapper {
    display: flex;
  }

  &-items {
    cursor: pointer;
    font-size: 14px;
    min-width: 100px;
    line-height: 19px;
    text-align: center;
    color: #9da3ac;
    padding: 5px 15px;
    font-weight: 400;
    border-bottom: 1px solid #ecf1f7;
    white-space: nowrap;
  }


}

.active {
  color: #2c3e50;
  font-weight: 600;
  position: relative;

  &::after {
    content: "";
    position: absolute;
    top: calc(100% - 0.5px);
    left: 0;
    width: 100%;
    height: 2px;
    background: #38B4CF;
  }


}

</style>
